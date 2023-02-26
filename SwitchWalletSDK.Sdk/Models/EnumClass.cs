using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    internal class EnumClass
    {
    }
    /// <summary>
    /// 
    /// <br/>
    /// <br/>1 = Deposit
    /// <br/>
    /// <br/>2 = Withdrawal
    /// </summary>
    public enum TransactionType
    {

        Deposit = 1,

        Withdrawal = 2,

    }
    public enum EnvironmentType
    {

        Sandbox = 1,

        Production = 2,

    }
}
