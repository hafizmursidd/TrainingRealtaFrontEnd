namespace TranScopeCommon
{
    public interface ITranScope
    {
        TranScopeResultDTO ProcessWithoutTransaction(int poProcessRecordCount);
        TranScopeResultDTO ProcessAllWithTransaction(int poProcessRecordCount);
        TranScopeResultDTO ProcessEachTransaction(int poProcessRecordCount);
    }
}