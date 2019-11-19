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
        /// ��ɫ��
        /// </summary>
        public RoleDBModel RoleDBModel { get; private set; }

        /// <summary>
        /// ���±�
        /// </summary>
        public StoryDBModel StoryDBModel { get; private set; }

        /// <summary>
        /// ��ͼ��
        /// </summary>
        public MapDBModel MapDBModel { get; private set; }

        /// <summary>
        /// NPC��
        /// </summary>
        public NPCDBModel NPCDBModel { get; private set; }

        /// <summary>
        /// ��ʼ��DBModel
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
            //ÿ����LoadData
            MapDBModel.LoadData();
            NPCDBModel.LoadData();
            StoryDBModel.LoadData();
            RoleDBModel.LoadData();
  

            //���б�Load���
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadDataTableComplete);
        }

        /// <summary>
        /// �첽���ر��
        /// </summary>
        public void LoadDataTableAsync()
        {
            Task.Factory.StartNew(LoadDataTable);
        }

        public void Clear()
        {
            //ÿ����Clear

            MapDBModel.Clear();
            NPCDBModel.Clear();
            RoleDBModel.Clear();
            StoryDBModel.Clear();

        }
    }
}
