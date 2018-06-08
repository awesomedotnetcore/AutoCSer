﻿using System;

namespace AutoCSer.CacheServer.Cache.MessageQueue.QueueTaskThread
{
    /// <summary>
    /// 释放队列数据 读文件
    /// </summary>
    internal sealed class DisposeQueueReaders : Node
    {
        /// <summary>
        /// 队列数据 读文件
        /// </summary>
        private readonly System.Collections.Generic.Dictionary<int, File.QueueReader> readers;
        /// <summary>
        /// 释放队列数据 读文件
        /// </summary>
        /// <param name="messageQueue">消息队列节点</param>
        /// <param name="readers"></param>
        internal DisposeQueueReaders(MessageQueue.Node messageQueue, System.Collections.Generic.Dictionary<int, File.QueueReader> readers) : base(messageQueue)
        {
            this.readers = readers;
        }
        /// <summary>
        /// 释放队列数据 读文件
        /// </summary>
        /// <returns></returns>
        internal override Node RunTask()
        {
            foreach (File.QueueReader reader in readers.Values) reader.Dispose();
            return LinkNext;
        }
    }
}
