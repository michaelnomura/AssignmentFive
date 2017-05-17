using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    Community_AssistEntities db = new Community_AssistEntities();

    public List<GrantRequest> GetGrant(int key)
    {
        //select grants using PersonKey
        var grq = from g in db.GrantRequests
                  where g.PersonKey == key
                  select g;

        //new list of grants
        List<GrantRequest> grants = new List<GrantRequest>();

        //loop through all results 
        foreach (var gr in grq)
        {
            //add info to list
            GrantRequest g01 = new GrantRequest();
            g01.GrantRequestDate = gr.GrantRequestDate;
            g01.GrantRequestAmount = gr.GrantRequestAmount;
            g01.GrantRequestExplanation = gr.GrantRequestExplanation;
            g01.GrantRequestKey = gr.GrantRequestKey;
            g01.GrantTypeKey = gr.GrantTypeKey;
            grants.Add(g01);

        }
        //reutrn result
        return grants;
    }

    public int Login(string user, string password)
    {
        //initialize variable
        int key = 0;
        int result = db.usp_Login(user, password);
        if (result != -1)
        {
            var userKey = (from k in db.People
                           where k.PersonEmail.Equals(user)
                           select k.PersonKey).FirstOrDefault();
            key = (int)userKey;
        }

        return key;
    }

    public bool Register(PersonInfo i)
    {
        //register using the stored procedure
        bool result = true;
        int rev = db.usp_Register(i.lastName,
            i.firstName, i.email, i.password.ToString(),
            i.apartment, i.street, i.city, i.state, i.zip,
            i.workPhone, i.homePhone);

        return result;
    }

    public bool RequestGrant(GrantRequest r)
    {
        bool result01 = true;
        //int rev = db.usp_AddRequest(r.GrantTypeKey, r.GrantRequestExplanation,
        //r.GrantRequestAmount, r.PersonKey);
        try
        {
            db.GrantRequests.Add(r);
            db.SaveChanges();
        }
        catch
        {
            result01 = false;
        }
        

        return result01;
    }
}
