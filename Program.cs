namespace DynamicList
{
    public class DynamicList
    {
        private class Node
        {
            public object Element { get; set; }
            public Node Next { get; set; }

            public Node(object element, Node next = null)
            {
                this.Element = element;
                this.Next = next;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(object item)
        {
            Node node = new Node(item);
            if (head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                this.tail = node;
            }
            this.count++;
        }

        public object Remove(int index)
        {
            if ( index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = this.head;
            Node before = null;

            
            for (int i = 0; i < index; i++)
            {
                before = current;
                current = current.Next;
            }

            
            if (before == null)
            {
                
                this.head = current.Next;
                if (this.head == null)
                {
                    this.tail = null; 
                }
            }
            else
            {
                before.Next = current.Next;
                if (current == this.tail)
                {
                    this.tail = before;
                }
            }

            this.count--;
            return current.Element;
        }

        public int Remove(object item)
        {
            Node current = this.head;
            Node previous = null;
            int index = 0;

            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    
                    if (previous == null)
                    {
                       
                        this.head = current.Next;
                        if (this.head == null)
                        {
                            this.tail = null; 
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current == this.tail)
                        {
                            this.tail = previous;
                        }
                    }

                    this.count--;
                    return index;
                }

                previous = current;
                current = current.Next;
                index++;
            }

            return -1; 
        }

        public int IndexOf(object item)
        {
            Node current = this.head;
            int index = 0;

            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1; 
        }

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public object this[int index]
        {
            get
            {
                if ( index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = this.head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Element;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
