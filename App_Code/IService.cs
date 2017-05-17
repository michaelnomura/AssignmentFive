using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    int Login(string user, string password);

    [OperationContract]
    bool Register(PersonInfo i);

    [OperationContract]
    bool RequestGrant(GrantRequest r);

    [OperationContract]
    List<GrantRequest> GetGrant(int key);

}

[DataContract]
public class PersonInfo
{
    [DataMember]
    public string lastName { get; set; }

    [DataMember]
    public string firstName { get; set; }

    [DataMember]
    public string email { get; set; }

    [DataMember]
    public string password { get; set; }

    [DataMember]
    public string apartment { get; set; }

    [DataMember]
    public string street { get; set; }

    [DataMember]
    public string city { get; set; }

    [DataMember]
    public string state { get; set; }

    [DataMember]
    public string zip { get; set; }

    [DataMember]
    public string homePhone { get; set; }

    [DataMember]
    public string workPhone { get; set; }

}
