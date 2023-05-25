    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using System;

    public class QuizUI : MonoBehaviour
    {
        [SerializeField] private Text m_question = null;
        [SerializeField] private List<OptionPlayer> m_buttonList = null;

        public void Construct(Question q , Action<OptionPlayer> callback)
        {
            m_question.text = q.text;

            for(int n = 0 ; n < m_buttonList.Count ; n++)
            {
                m_buttonList[n].Construct(q.options[n], callback);
            }
        }
    }
