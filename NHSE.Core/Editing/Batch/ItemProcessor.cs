namespace NHSE.Core
{
    public class ItemProcessor : BatchProcessor<Item>
    {
        public ItemProcessor(BatchMutator<Item> mut) : base(mut)
        {
        }

        protected override bool CanModify(Item item) => true;
        protected override bool Finalize(Item item) => true;
    }
}
