using Doom3D.Constants;
using Doom3D.Core.Models;
using System.Windows.Forms;

namespace Doom3D.Core
{
    public partial class Controller
    {
        GameModel gameModel;

        public Controller(Screen screen, Mode mode)
        {
            string pathToLevelMap = "";//из-за этого может возникнуть ошибка
            switch (mode)
            {
                case Mode.OnTime:
                    pathToLevelMap = Paths.OnTimeLevel;
                    break;
                //todo
            }
            InitGameState(screen, DataBase.GetGameField(pathToLevelMap));
            gameModel.Start();
        }

        public void InitGameState(Screen screen, GameField gameFiled)
        {
            gameModel = new OnTimeModel(screen, gameFiled);
        }

        
    }
}
