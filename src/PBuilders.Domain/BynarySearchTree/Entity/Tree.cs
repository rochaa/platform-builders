using System;
using MongoDB.Bson.Serialization.Attributes;
using PBuilders.Domain.BynarySearchTree.ValueObject;

namespace PBuilders.Domain.BynarySearchTree.Entity
{
    [BsonIgnoreExtraElements]
    public class Tree
    {
        public Node? Root { get; private set; }

        public Node InsertNode(Node? node, int value)
        {
            if (node == null)
            {
                Root = new Node(value);
                return Root;
            }
            else if (value < node.Value)
            {
                var left = InsertNode(node.Left, value);
                node.InsertLeft(left);
            }
            else
            {
                var right = InsertNode(node.Right, value);
                node.InsertRight(right);
            }

            return node;
        }

        public void InsertValues(params int[] values)
        {
            foreach (var value in values)
                Root = InsertNode(Root, value);
        }

        public Tree GenerateRandomTree()
        {
            var nodeAmount = 10;

            for (int i = 0; i < nodeAmount; i++)
                Root = InsertNode(Root, new Random().Next(1000));

            return this;
        }

        public Node GetNodeByValue(Node? node, int value)
        {
            if (node?.Value == value)
                return node;
            else if (node?.Value < value)
                return GetNodeByValue(node?.Right, value);
            else
                return GetNodeByValue(node?.Left, value);
        }
    }
}