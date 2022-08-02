using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
	public class LRUCacheProblem : IProblem
	{
		public void Execute()
		{
			var lRUCache = new LRUCache(2);
			lRUCache.Put(1, 1); // cache is {1=1}
			lRUCache.Put(2, 2); // cache is {1=1, 2=2}
			Console.WriteLine(lRUCache.Get(1));    // return 1
			lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
			Console.WriteLine(lRUCache.Get(2));    // returns -1 (not found)
			lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
			Console.WriteLine(lRUCache.Get(1));    // return -1 (not found)
			lRUCache.Get(3);    // return 3
			lRUCache.Get(4);    // return 4
		}
	}

	public class LRUCache {
		private Dictionary<int, DListNode> _dict;
		private int _capacity;
		private DListNode head = new DListNode();
		private DListNode tail = new DListNode();
    
		public LRUCache(int capacity)
		{
			_dict = new Dictionary<int, DListNode>(capacity);
			_capacity = capacity;
			head.next = tail;
			tail.prev = head;
		}
    
		public int Get(int key)
		{
			if (!_dict.TryGetValue(key, out var node))
				return -1;
			
			MoveToHead(node);
			return node.val;
		}
    
		public void Put(int key, int value) {
			if (_dict.ContainsKey(key))
			{
				var node = _dict[key];
				node.val = value;
				MoveToHead(node);
				return;
			}
        
			if (_dict.Count == _capacity)
			{
				var node = PopNode();
				_dict.Remove(node.key);
			}

			var newNode = new DListNode(key, value);
			_dict[key] = newNode;
			AddAfterHead(newNode);
		}
    
		private void AddAfterHead(DListNode node)
		{
			node.next = head.next;
			node.prev = head;

			head.next.prev = node;
			head.next = node;
		}
    
		private DListNode RemoveNode(DListNode node)
		{
			node.next.prev = node.prev;
			node.prev.next = node.next;

			return node;
		}

		private void MoveToHead(DListNode node)
		{
			RemoveNode(node);
			AddAfterHead(node);
		}
    
		private DListNode PopNode()
		{
			var node = tail.prev;
			RemoveNode(node);
			return node;
		}
	}

	public class DListNode {
		public int val;
		public int key;
		public DListNode next;
		public DListNode prev;
    
		public DListNode(){
        
		}
    
		public DListNode(int key, int val){
			this.val = val;
			this.key = key;
		}
    
		public DListNode(int val, DListNode prev, DListNode next){
			this.val = val;
			this.prev = prev;
			this.next = next;
		}
	}
}