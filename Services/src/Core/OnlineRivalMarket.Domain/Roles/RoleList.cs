using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Roles
{
    public sealed class RoleList
    {
        public static List<AppRole> GetStaticRoles()
        {
            List<AppRole> appRoles = new List<AppRole>
        {
             #region PRODUCT
            new AppRole(title: PRODUCT,code : PRODUCTCreateCode,name : PRODUCTCreateName),
            new AppRole(title: PRODUCT,code : PRODUCTUpdateCode,name : PRODUCTUpdateName),
            new AppRole(title: PRODUCT,code : PRODUCTRemoveCode,name : PRODUCTRemoveName),
            new AppRole(title: PRODUCT,code : PRODUCTReadCode,  name : PRODUCTReadName),
	        #endregion               
             #region CUSTOMER
            new AppRole(title: CUSTOMER,code : CUSTOMERCreateCode,name : CUSTOMERCreateName),
            new AppRole(title: CUSTOMER,code : CUSTOMERUpdateCode,name : CUSTOMERUpdateName),
            new AppRole(title: CUSTOMER,code : CUSTOMERRemoveCode,name : CUSTOMERRemoveName),
            new AppRole(title: CUSTOMER,code : CUSTOMERReadCode,  name : CUSTOMERReadName),
	        #endregion                 
        };
            return appRoles;
        }
        public static List<MainRole> GetStaticMainRoles()
        {
            List<MainRole> mainRoles = new List<MainRole>
        {
            new MainRole(Guid.NewGuid().ToString(),"Admin",true),
            new MainRole(Guid.NewGuid().ToString(),"Yönetici",true),
            new MainRole(Guid.NewGuid().ToString(),"Kullanıcı",true),
        };
            return mainRoles;
        }
        public static string PRODUCT = "URUNLER";
        public static string CUSTOMER = "MUSTERILER";
        public static string DOCUMENTS = "DOKUMANLAR";
        public static string BASKETSTATUS = "SEPET DURUMU";
        public static string PRODUCTCOMPANIES = "URUN KAMPANYALARI";


        public static string PRODUCTCreateCode = "PRODUCT.CREATE";
        public static string PRODUCTCreateName = "URUN KAYIT";
        public static string PRODUCTUpdateCode = "PRODUCT.UPDATE";
        public static string PRODUCTUpdateName = "URUN GUNCELLE";
        public static string PRODUCTRemoveCode = "PRODUCT.REMOVE";
        public static string PRODUCTRemoveName = "URUN SIL";
        public static string PRODUCTReadCode = "PRODUCT.READ";
        public static string PRODUCTReadName = "URUN GORUNTULE";

        public static string CUSTOMERCreateCode = "CUSTOMER.CREATE";
        public static string CUSTOMERCreateName = "MUSTERI KAYIT";
        public static string CUSTOMERUpdateCode = "CUSTOMER.UPDATE";
        public static string CUSTOMERUpdateName = "MUSTERI GUNCELLE";
        public static string CUSTOMERRemoveCode = "CUSTOMER.REMOVE";
        public static string CUSTOMERRemoveName = "MUSTERI SIL";
        public static string CUSTOMERReadCode = "CUSTOMER.READ";
        public static string CUSTOMERReadName = "MUSTERI GORUNTULE";
    }
}
