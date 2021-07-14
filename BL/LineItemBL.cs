using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class LineItemBL
    {
        private LineRepository _repo;
        public LineItemBL(LineRepository p_repo)
        {
            _repo=p_repo;
        }
        public void AddLineItems(List<LineItems> _cAdd)
        {
            foreach (LineItems item in _cAdd)
            {
                _repo.AddLineItems(item);
            }
        }
        public LineItems GetItemByLine(string p_LineItemNumber)
        {
            return _repo.GetItemByLine(p_LineItemNumber);
        }
    }
}