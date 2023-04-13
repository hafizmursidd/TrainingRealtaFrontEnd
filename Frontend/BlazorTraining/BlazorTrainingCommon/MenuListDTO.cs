using System;

namespace BlazorTrainingCommon
{
    public class MenuListDTO
    {
        //public string CCOMPANY_ID { get; set; }
        //public string CUSER_ID { get; set; }
        public string CMENU_ID { get; set; }
        public string CMENU_NAME { get; set; }
        public string CSUB_MENU_TYPE { get; set; }
        public string CSUB_MENU_ID { get; set; }
        public string CSUB_MENU_NAME { get; set; }
        //public string CSUB_MENU_TOOL_TIP { get; set; }
        //public string CSUB_MENU_IMAGE { get; set; }
        public string CPARENT_SUB_MENU_ID { get; set; }
        public Nullable<int> IGROUP_INDEX { get; set; }
        //public Nullable<int> IROW_INDEX { get; set; }
        //public Nullable<int> ICOLUMN_INDEX { get; set; }
        //public bool LFAVORITE { get; set; }
        public Nullable<int> IFAVORITE_INDEX { get; set; }
        //public int ILEVEL { get; set; }
        public string CSUB_MENU_ACCESS { get; set; } = "A,U,D,P,V"; // tambahin di service
    }
}
