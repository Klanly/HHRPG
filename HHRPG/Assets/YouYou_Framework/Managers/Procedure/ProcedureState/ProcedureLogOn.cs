using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YouYou
{
    /// <summary>
    /// µÇÂ¼Á÷³Ì
    /// </summary>
    public class ProcedureLogOn : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if(SceneManager.GetActiveScene().name!= "MainMenu")
            {
                SceneManager.LoadScene("MainMenu");
            }
            GameEntry.Procedure.ChangeState(ProcedureState.SelectRole);
        }

        public override void OnLeave()
        {
            base.OnLeave();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
