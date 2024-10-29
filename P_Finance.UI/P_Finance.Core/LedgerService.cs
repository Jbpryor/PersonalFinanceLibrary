using P_Finance.Core.Models;

namespace P_Finance.Core
{
    public class LedgerService
    {
        public static void CreateLedger<T>(T model) where T : class
        {
            if (model is DepositModel deposit)
            {
                AddLedger(deposit.Date, $"Deposit - {deposit.Name}", deposit.Amount, deposit.Id, 1);
            }
            //else if (model is WithdrawalModel withdrawal)
            //{
            //    AddLedger(withdrawal.Date, $"Withdrawl - {withdrawal.Name}", withdrawal.Amount, withdrawal.Id, 2);
            //}

            else if (model is PurchaseModel purchase)
            {
                AddLedger(purchase.Date, $"Purchase - {purchase.Name}", -purchase.Amount, purchase.Id, 3);
            }
            //else if (model is CreditModel credit)
            //{
            //    AddLedger(credit.Date, $"Credit - {credit.Name}", -credit.Amount, credit.Id, 4);
            //}
        }

        private static async void AddLedger(DateTime date, string name, decimal amount, int fromId, int modelId)
        {
            var ledger = new LedgerModel
            {
                Id = 0,
                Date = date,
                Name = name,
                Amount = amount,
                FromId = fromId,
                ModelId = modelId
            };
            await GlobalConfig.Connection!.CreateLedger(ledger);
        }

        //public void UpdateLedger<T>(T model) where T : class
        //{
        //    LedgerModel? ledger = null;

        //    if (model is DepositModel deposit)
        //    {
        //        ledger = _unitOfWork.Ledger.Get(l => l.FromId == deposit.Id && l.ModelId == 1);
        //        if (ledger != null)
        //        {
        //            UpdateEntry(ledger, $"Deposit - {deposit.Name}", deposit.Amount);
        //        }
        //    }
        //    else if (model is WithdrawalModel withdrawal)
        //    {
        //        ledger = _unitOfWork.Ledger.Get(l => l.FromId == withdrawal.Id && l.ModelId == 2);
        //        if (ledger != null)
        //        {
        //            UpdateEntry(ledger, $"Withdrawl - {withdrawal.Name}", withdrawal.Amount);
        //        }
        //    }
        //    else if (model is PurchaseModel purchase)
        //    {
        //        ledger = _unitOfWork.Ledger.Get(l => l.FromId == purchase.Id && l.ModelId == 3);
        //        if (ledger != null)
        //        {
        //            UpdateEntry(ledger, $"Purchase - {purchase.Name}", -purchase.Amount);
        //        }
        //    }
        //    else if (model is CreditModel credit)
        //    {
        //        ledger = _unitOfWork.Ledger.Get(l => l.FromId == credit.Id && l.ModelId == 4);
        //        if (ledger != null)
        //        {
        //            UpdateEntry(ledger, $"Credit - {credit.Name}", -credit.Amount);
        //        }
        //    }

        //    if (ledger != null)
        //    {
        //        _unitOfWork.Ledger.Update(ledger);
        //        SaveLedger();
        //    }
        //}
        //private void UpdateEntry(LedgerModel ledger, string name, decimal amount)
        //{
        //    ledger.Name = name;
        //    ledger.Amount = amount;
        //}


        //private void SaveLedger()
        //{
        //    _unitOfWork.Save();
        //}
    }
}

