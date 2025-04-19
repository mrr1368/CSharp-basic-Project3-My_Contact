using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_basic_Project3_My_Contact.Repository
{
    internal interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactid);
        DataTable Search(string searchText);
        bool Insert(string firstName, string lastName, int age, string phoneNumber, string emailAddress, string address);
        bool Update(int contactId, string firstName, string lastName, int age, string phoneNumber, string emailAddress, string address);
        bool Delete(int contactId);
    }
}
