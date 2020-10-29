﻿//
// JBehaviour.cs
//
// Author:
//       JasonXuDeveloper（傑） <jasonxudeveloper@gmail.com>
//
// Copyright (c) 2020 JEngine
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JEngine.Core
{
    /// <summary>
    /// JEngine's Behaviour
    /// </summary>
    public class JBehaviour : IJBehaviour
    {
        /// <summary>
        /// Constuctor
        /// 构造函数
        /// </summary>
        public JBehaviour()
        {
            //启动线程
            if(DestoryListner.ThreadState == System.Threading.ThreadState.Unstarted)
            {
                DestoryListner.Start();
            }

            //添加实例ID
            _instanceID = System.Guid.NewGuid().ToString("N");
            while (JBehaviours.ContainsKey(_instanceID))
            {
                _instanceID = System.Guid.NewGuid().ToString("N");
            }
            JBehaviours.Add(_instanceID, this);
        }

        #region STATIC METHODS
        /// <summary>
        /// Create a JBehaviour on a gameObject
        /// 在游戏对象上创建JBehaviour
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <param name="activeAfter"></param>
        /// <returns></returns>
        public static T CreateOn<T>(GameObject gameObject, bool activeAfter = true) where T : JBehaviour
        {
            var jBehaviour = typeof(T);
            var cb = gameObject.AddComponent<ClassBind>();
            var _cb = new _ClassBind()
            {
                Namespace = jBehaviour.Namespace,
                Class = jBehaviour.Name,
                ActiveAfter = activeAfter,
                UseConstructor = true
            }; ;
            var id = cb.AddClass(_cb);
            UnityEngine.Object.Destroy(cb);
            return (T)JBehaviours[id];
        }

        /// <summary>
        /// Get JBehaviour from a gameObject
        /// 通过游戏对象获取JBehaviour
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetJBehaviour<T>(GameObject gameObject) where T : JBehaviour
        {
            return (T)JBehaviours.Values.ToList().Find(jb => jb._gameObject == gameObject);
        }

        /// <summary>
        /// Get JBehaviour from an instance id
        /// 通过实例ID获取JBehaviour
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetJBehaviour<T>(string instanceID) where T : JBehaviour
        {
            return (T)JBehaviours.Values.ToList().Find(jb => jb._instanceID == instanceID);
        }

        /// <summary>
        /// Get All JBehaviour from a gameObject
        /// 通过游戏对象获取全部JBehaviour
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T[] GetJBehaviours<T>(GameObject gameObject) where T : JBehaviour
        {
            return (T[])JBehaviours.Values.ToList().FindAll(jb => jb._gameObject == gameObject).ToArray();
        }

        /// <summary>
        /// Remove a JBehaviour
        /// </summary>
        /// <param name="jBehaviour"></param>
        public static void RemoveJBehaviour(JBehaviour jBehaviour)
        {
            UnityEngine.Object.Destroy(GetJBehaviourInEditor(jBehaviour));
            jBehaviour.Destroy();
        }

        /// <summary>
        /// Get a JBehaviour in Editor
        /// </summary>
        /// <param name="jBehaviour"></param>
        /// <returns></returns>
        private static MonoBehaviourAdapter.Adaptor GetJBehaviourInEditor(JBehaviour jBehaviour)
        {
            var f = typeof(JBehaviour).GetField("_instanceID", BindingFlags.NonPublic);
            return jBehaviour._gameObject.GetComponents<MonoBehaviourAdapter.Adaptor>()
                .ToList()
                .Find(a =>
                f != null &&
                f.GetValue(a.ILInstance).ToString() == jBehaviour._instanceID);
        }



        #endregion


        #region FIELDS + PROPERTIES

        /// <summary>
        /// All JBehaviuours
        /// 全部JBehaviour
        /// </summary>
        private static Dictionary<string, JBehaviour> JBehaviours = new Dictionary<string, JBehaviour>(0);


        /// <summary>
        /// Destory Thread
        /// 销毁JBehaviour的线程
        /// </summary>
        private static Thread DestoryListner = new Thread(ListenDestroy);

        /// <summary>
        /// Listen to destory
        /// 监听销毁
        /// </summary>
        private async static void ListenDestroy()
        {
            while (JBehaviours != null)
            {
                var e = JBehaviours.GetEnumerator();
                while (e.MoveNext())
                {
                    if (e.Current.Value._gameObject == null)
                    {
                        e.Current.Value._cancellationTokenSource.Cancel();
                    }
                }
                await Task.Delay(5);
            }
        }

        /// <summary>
        /// Instance ID
        /// 实例ID
        /// </summary>
        public string InstanceID => _instanceID;
        private string _instanceID;

        /// <summary>
        /// GameObject of this instance
        /// 游戏对象
        /// </summary>
        public GameObject gameObject => _gameObject;
        private GameObject _gameObject;

        /// <summary>
        /// Cancel the loop
        /// 取消循环
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Loop in frame or millisecond
        /// 帧模式或毫秒模式
        /// </summary>
        public bool FrameMode = true;

        /// <summary>
        /// Frequency of loop, if frame = false, this field stands for milliseconds
        /// 循环频率，如果是毫秒模式，单位就是ms
        /// </summary>
        public int Frequency = 1;

        /// <summary>
        /// Total time that this JBehaviour has run
        /// 该JBehaviour运行总时长
        /// </summary>
        public float TotalTime = 0;

        /// <summary>
        /// Deltatime of loop
        /// 循环耗时
        /// </summary>
        public float LoopDeltaTime = 0;

        /// <summary>
        /// Loop counts
        /// 循环次数
        /// </summary>
        public long LoopCounts = 0;


        /// <summary>
        /// Time scale
        /// 时间倍速
        /// </summary>
        public float TimeScale = 1;

        /// <summary>
        /// Pause before init
        /// 是否暂停
        /// </summary>
        private bool Paused = false;

        #endregion

        #region METHODS
        /// <summary>
        /// Hides the UI gameObject
        /// 隐藏UI对象
        /// </summary>
        public JBehaviour Hide()
        {
            if (this._gameObject != null)
            {
                this._gameObject.SetActive(false);
            }
            return this;
        }

        /// <summary>
        /// Shows the UI gameObject
        /// 显示UI对象
        /// </summary>
        public JBehaviour Show()
        {
            if (this._gameObject != null)
            {
                this._gameObject.SetActive(true);
            }
            return this;
        }

        /// <summary>
        /// Pause the loop
        /// 暂停循环
        /// </summary>
        public JBehaviour Pause()
        {
            Paused = true;
            return this;
        }

        /// <summary>
        /// Resume the loop
        /// 恢复循环
        /// </summary>
        public JBehaviour Resume()
        {
            Paused = false;
            return this;
        }

        /// <summary>
        /// Activate the JBehaviour
        /// 激活
        /// </summary>
        /// <returns></returns>
        public JBehaviour Activate()
        {
            this.Awake();
            return this;
        }
        #endregion

        #region INTERNAL

        /// <summary>
        /// Launch the lifecycle
        /// 开始生命周期
        /// </summary>
        private protected void Launch()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                Init();
            }
            catch(Exception e)
            {
                Log.PrintError($"{_gameObject.name}<{_instanceID}> Init failed: {e.Message}, skipped init");
            }

            try
            {
                Run();
            }
            catch (Exception e)
            {
                Log.PrintError($"{_gameObject.name}<{_instanceID}> Run failed: {e.Message}, skipped run");
            }

            if (Frequency == 0)
            {
                Frequency = 1;
            }

            sw.Stop();
            TotalTime += sw.ElapsedMilliseconds / 1000f;

            DoLoop();
        }

        /// <summary>
        /// Do the loop
        /// </summary>
        private protected async void DoLoop()
        {
            Stopwatch sw = new Stopwatch();

            while (_gameObject != null)
            {
                sw.Reset();
                sw.Start();

                if (Paused)//暂停
                {
                    await Task.Delay(25);
                    continue;
                }

                try//循环
                {
                    Loop();
                }
                catch (Exception ex)
                {
                    Log.PrintError($"{_gameObject.name}<{_instanceID}> Loop failed: {ex.Message}");
                }

                if (TimeScale < 0.1f)
                {
                    TimeScale = 1;
                }

                int duration;
                if (FrameMode)//等待
                {
                    duration = (int)(((float)Frequency / ((float)Application.targetFrameRate <= 0 ? GameStats.fps : Application.targetFrameRate)) * 1000f);
                    duration = (int)(duration / TimeScale);
                }
                else
                {
                    duration = Frequency;
                    duration = (int)(duration / TimeScale);
                }
                if (duration < -1)
                {
                    duration = 1;
                }
                await Task.Delay(duration, _cancellationTokenSource.Token);

                sw.Stop();

                //操作时间
                var time = sw.ElapsedMilliseconds / 1000f;
                LoopCounts++;
                LoopDeltaTime = time;
                TotalTime += time;
            }

            Destroy();
        }

        /// <summary>
        /// Call end method
        /// 调用周期销毁
        /// </summary>
        private protected void Destroy()
        {
            JBehaviours.Remove(this._instanceID);
            End();
        }

        /// <summary>
        /// Call to launch JBehaviour
        /// 启动生命周期
        /// </summary>
        private protected void Awake()
        {
            if (_gameObject == null)
            {
                Log.Print($"JBehaviour can't be created by new JBehaviour()," +
                    $" therefore, a new GameObject {_instanceID} has been created");
                Log.Print($"GameObject {_instanceID} will not show " +
                    $"anything that you created by new() in inspector");
                _gameObject = new GameObject(_instanceID);
            }
            Launch();
        }
        #endregion


        #region METHODS THAT ARE REWRITABLE

        public virtual void Init()
        {

        }

        public virtual void Run()
        {

        }

        public virtual void Loop()
        {

        }

        public virtual void End()
        {

        }
        #endregion
    }

    /// <summary>
    /// JBehaviour Interface
    /// </summary>
    interface IJBehaviour
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();

        /// <summary>
        /// 开始
        /// </summary>
        void Run();

        /// <summary>
        /// 循环
        /// </summary>
        void Loop();

        /// <summary>
        /// 销毁
        /// </summary>
        void End();
    }
}