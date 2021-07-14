using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class GamesBL
    {
        private GameRepository _repo;
        public GamesBL(GameRepository p_repo)
        {
            _repo=p_repo;
        }
        public List<Games> GetAllGames()
        {
            return _repo.GetAllGames();
        }
        public List<Games> FilterGame(Games p_game)
        {
            return _repo.FilterGame(p_game);
        }

    }
    public class SystemsBL
    {
        private SystemRepository _repo;
        public SystemsBL(SystemRepository p_repo)
        {
            _repo=p_repo;
        }
        public List<Systems> GetAllSystems()
        {
            return _repo.GetAllSystems();
        }
        public List<Systems> FilterSystems(Systems p_system)
        {
            return _repo.FilterSystems(p_system);
        }
    }
}