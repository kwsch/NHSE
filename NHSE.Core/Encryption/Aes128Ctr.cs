﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NHSE.Core
{
    // The MIT License (MIT)

    // Copyright (c) 2014 Hans Wolff

    // Permission is hereby granted, free of charge, to any person obtaining a copy
    // of this software and associated documentation files (the "Software"), to deal
    // in the Software without restriction, including without limitation the rights
    // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the Software is
    // furnished to do so, subject to the following conditions:

    // The above copyright notice and this permission notice shall be included in
    // all copies or substantial portions of the Software.

    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    // THE SOFTWARE.

    public sealed class Aes128CounterMode : SymmetricAlgorithm
    {
        private readonly byte[] _counter;
        private readonly AesManaged _aes = new() {Mode = CipherMode.ECB, Padding = PaddingMode.None};

        public Aes128CounterMode(byte[] counter)
        {
            const int expect = 0x10;
            if (counter.Length != expect)
                throw new ArgumentException($"Counter size must be same as block size (actual: {counter.Length}, expected: {expect})");
            _counter = counter;
        }

        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] ignoredParameter) => new CounterModeCryptoTransform(_aes, rgbKey, _counter);
        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] ignoredParameter) => new CounterModeCryptoTransform(_aes, rgbKey, _counter);

        public override void GenerateKey() => _aes.GenerateKey();
        public override void GenerateIV() { /* IV not needed in Counter Mode */ }
        protected override void Dispose(bool disposing) => _aes.Dispose();
    }

    public sealed class CounterModeCryptoTransform : ICryptoTransform
    {
        private readonly byte[] _counter;
        private readonly ICryptoTransform _counterEncryptor;
        private readonly Queue<byte> _xorMask = new();
        private readonly SymmetricAlgorithm _symmetricAlgorithm;

        public CounterModeCryptoTransform(SymmetricAlgorithm symmetricAlgorithm, byte[] key, byte[] counter)
        {
            if (counter.Length != symmetricAlgorithm.BlockSize / 8)
                throw new ArgumentException($"Counter size must be same as block size (actual: {counter.Length}, expected: {symmetricAlgorithm.BlockSize / 8})");

            _symmetricAlgorithm = symmetricAlgorithm;
            _encryptOutput = new byte[counter.Length];
            _counter = counter;

            var zeroIv = new byte[counter.Length];
            _counterEncryptor = symmetricAlgorithm.CreateEncryptor(key, zeroIv);
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            var output = new byte[inputCount];
            TransformBlock(inputBuffer, inputOffset, inputCount, output, 0);
            return output;
        }

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            var xm = _xorMask;
            for (var i = 0; i < inputCount; i++)
            {
                if (xm.Count == 0)
                    EncryptCounterThenIncrement();

                var mask = xm.Dequeue();
                outputBuffer[outputOffset + i] = (byte)(inputBuffer[inputOffset + i] ^ mask);
            }

            return inputCount;
        }

        private readonly byte[] _encryptOutput;

        private void EncryptCounterThenIncrement()
        {
            var counterModeBlock = _encryptOutput;

            _counterEncryptor.TransformBlock(_counter, 0, _counter.Length, counterModeBlock, 0);
            IncrementCounter();

            var xm = _xorMask;
            foreach (var b in counterModeBlock)
                xm.Enqueue(b);
        }

        private void IncrementCounter()
        {
            var ctr = _counter;
            for (var i = ctr.Length - 1; i >= 0; i--)
            {
                if (++ctr[i] != 0)
                    break;
            }
        }

        public int InputBlockSize => _symmetricAlgorithm.BlockSize / 8;
        public int OutputBlockSize => _symmetricAlgorithm.BlockSize / 8;
        public bool CanTransformMultipleBlocks => true;
        public bool CanReuseTransform => false;

        public void Dispose() => _counterEncryptor.Dispose();
    }
}
