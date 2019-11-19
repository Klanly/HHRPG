using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace YouYou
{
    public class DataTableManager : ManagerBase
    {
        public DataTableManager()
        {
           InitDBModel();
        }

        /// <summary>
        /// 角色表
        /// </summary>
        public RoleDBModel RoleDBModel { get; private set; }

        /// <summary>
        /// 故事表
        /// </summary>
        public StoryDBModel StoryDBModel { get; private set; }

        /// <summary>
        /// 地图表
        /// </summary>
        public MapDBModel MapDBModel { get; private set; }

        /// <summary>
        /// NPC表
        /// </summary>
        public NPCDBModel NPCDBModel { get; private set; }

        /// <summary>
        /// 初始化DBModel
        /// </summary>
        private void InitDBModel()
        {
            NPCDBModel = new NPCDBModel();
            MapDBModel = new MapDBModel();
            StoryDBModel = new StoryDBModel();
            RoleDBModel = new RoleDBModel();
  
        }

        public void LoadDataTable()
        {
            //每个表都LoadData
            MapDBModel.LoadData();
            NPCDBModel.LoadData();
            StoryDBModel.LoadData();
            RoleDBModel.LoadData();
  

            //所有表Load完毕
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadDataTableComplete);
        }

        /// <summary>
        /// 异步加载表格
        /// </summary>
        public void LoadDataTableAsync()
        {
            Task.Factory.StartNew(LoadDataTable);
        }

        public void Clear()
        {
            //每个表都Clear

            MapDBModel.Clear();
            NPCDBModel.Clear();
            RoleDBModel.Clear();
            StoryDBModel.Clear();

        }
    }
}
