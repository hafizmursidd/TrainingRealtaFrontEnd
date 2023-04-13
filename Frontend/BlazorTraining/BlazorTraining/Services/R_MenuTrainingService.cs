using BlazorTrainingCommon;
using R_BlazorFrontEnd.State;

namespace BlazorTraining.Services
{
    public class R_MenuTrainingService : R_IMenuService
    {
        private readonly R_AccessStateContainer _stateContainer;

        public Dictionary<string, string[]> MenuAccess { get; private set; }

        public string[] MenuIdList { get; private set; }

        public R_MenuTrainingService(R_AccessStateContainer stateContainer)
        {
            _stateContainer = stateContainer;
        }

        public Task<List<MenuListDTO>> GetMenuAsync()
        {
            var loResult = new List<MenuListDTO>();

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "Ex",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "G001",
                CSUB_MENU_NAME = "Conductor Child",
                CSUB_MENU_TYPE = "G",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 1
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB00600",
                CSUB_MENU_NAME = "Gridview Original",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB00700",
                CSUB_MENU_NAME = "Gridview Navigator",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB00900",
                CSUB_MENU_NAME = "Find with Conductor",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB01300",
                CSUB_MENU_NAME = "Original and Navigator",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB01400",
                CSUB_MENU_NAME = "Find and Navigator",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB00100",
                CSUB_MENU_NAME = "Training Find With Conductor",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            loResult.Add(new MenuListDTO
            {
                CMENU_ID = "Ex",
                CMENU_NAME = "Example",
                CPARENT_SUB_MENU_ID = "G001",
                CSUB_MENU_ACCESS = "A,U,D,P,V",
                CSUB_MENU_ID = "SAB00200",
                CSUB_MENU_NAME = "Training GridView Original",
                CSUB_MENU_TYPE = "P",
                IFAVORITE_INDEX = 0,
                IGROUP_INDEX = 0
            });

            return Task.FromResult(loResult);
        }

        public Task SetMenuAccessAsync()
        {
            var loResult = new List<MenuProgramAccessDTO>();

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB00600",
                CACCESS_ID = "A,U,D,P,V"
            });

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB00700",
                CACCESS_ID = "A,U,D,P,V"
            });

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB00900",
                CACCESS_ID = "A,U,D,P,V"
            });

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB01300",
                CACCESS_ID = "A,U,D,P,V"
            });

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB01400",
                CACCESS_ID = "A,U,D,P,V"
            });

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB00100",
                CACCESS_ID = "A,U,D,P,V"
            });

            loResult.Add(new MenuProgramAccessDTO
            {
                CPROGRAM_ID = "SAB00200",
                CACCESS_ID = "A,U,D,P,V"
            });

            MenuAccess = loResult.ToDictionary(x => x.CPROGRAM_ID, x => x.CACCESS_ID.Split(','));

            _stateContainer.SetValue(MenuAccess);

            return Task.CompletedTask;
        }
    }
}
