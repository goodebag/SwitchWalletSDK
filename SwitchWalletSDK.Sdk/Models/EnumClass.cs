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
    /// <summary>
    /// 
    /// <br/>
    /// <br/>1 = Currency
    /// <br/>
    /// <br/>2 = Network
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v11.0.0.0))")]
    public enum GroupByCategory
    {

        Currency = 1,

        Network = 2,

    }

    /// <summary>
    /// 
    /// <br/>
    /// <br/>1 = Day
    /// <br/>
    /// <br/>2 = Month
    /// <br/>
    /// <br/>3 = Year
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v11.0.0.0))")]
    public enum GroupByPeriod
    {

        Day = 1,

        Month = 2,

        Year = 3,

    }
}
