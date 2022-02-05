using System;
using System.Collections.Generic;

namespace FunctionLibrary
{
    
   //Definition for singly-linked list.
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
      {
            this.val = val;
            this.next = next;
      }
    }

    public class LinkedListFunctions    
    {

        public void CreateList()
        {

            //ListNode l = new ListNode(-1)
            //{
            //    next = new ListNode(5)
            //    {
            //        next = new ListNode(3)
            //        {
            //            next = new ListNode(4)
            //            {
            //                next = new ListNode(0)
            //            }
            //        }
            //    }
            //};

            ListNode l = new ListNode(2)
            {
                next = new ListNode(1)
            };
            PrintList(l);
            l = SortList(l);
            PrintList(l);
        }
        
        public void CreateAndMergeLists()
        {
            ListNode[] lists = new ListNode[3];

            ListNode l1 = new ListNode(1)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                }
            };

            ListNode l2 = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(4)
                }
            };

            ListNode l3 = new ListNode(2)
            {
                next = new ListNode(6)
            };

            //ListNode l1 = new ListNode(1)
            //{
            //    next = new ListNode(2)
            //    {
            //        next = new ListNode(2)
            //    }
            //};

            //ListNode l2 = new ListNode(1)
            //{
            //    next = new ListNode(1)
            //    {
            //        next = new ListNode(2)
            //    }
            //};



            lists[0] = l1;
            lists[1] = l2;
            lists[2] = l3;
            var sorted  = MergeKLists(lists);
            PrintList(sorted);
        }

        private void PrintList(ListNode sorted)
        {
            var tmp = sorted;
            while(tmp != null)
            {
                Console.Write(tmp.val+" ");
                tmp = tmp.next;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode prev, l3;
            l3 = new ListNode();
            var temp1 = l1;
            var temp2 = l2;
            ListNode temp3;

            prev = null;
            temp3 = l3;

            int sum, carry=0;
            while (temp1 != null && temp2 != null)
            {
                if (temp3 == null)
                    temp3 = new ListNode();
                if(prev != null)
                    prev.next = temp3;
                sum = (carry + temp1.val + temp2.val) % 10;
                carry = (carry + temp1.val + temp2.val) / 10;

                temp3.val = sum;
                prev = temp3;
                temp3 = temp3.next;
                temp1 = temp1.next;
                temp2 = temp2.next;
            }
            while(temp1 != null)
            {
                if (temp3 == null)
                    temp3 = new ListNode();
                if (prev != null)
                    prev.next = temp3;
                sum = (carry + temp1.val) % 10;
                carry = (carry + temp1.val) / 10;
                temp3.val = sum;
                prev = temp3;
                temp3 = temp3.next;
                temp1 = temp1.next;
            }
            while (temp2 != null)
            {
                if (temp3 == null)
                    temp3 = new ListNode();
                if (prev != null)
                    prev.next = temp3;
                sum = (carry + temp2.val) % 10;
                carry = (carry + temp2.val) / 10;
                temp3.val = sum;
                prev = temp3;
                temp3 = temp3.next;
                temp2 = temp2.next;
            }
            if(carry != 0)
            {
                if (temp3 == null)
                    temp3 = new ListNode();
                if (prev != null)
                    prev.next = temp3;
                temp3.val = carry;
                prev = temp3;
                temp3 = temp3.next;
            }
            return l3;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            else if (lists.Length < 2)
                return lists[0];
            return MergeSort3(lists);
        }

        private ListNode MergeSort(ListNode[] lists)
        {
            if(lists.Length == 2)
            {
                return MergeTwoLists(lists[0], lists[1]);
            }
            else
            {
                var subList =  new ArraySegment<ListNode>(lists, 1, lists.Length - 1).ToArray();
                if (subList == null)
                    return lists[0];
                
                return MergeTwoLists(lists[0], MergeSort(subList));
            }
        }
        private ListNode MergeSort3(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];
            if (lists.Length == 2)
            {
                return MergeTwoLists(lists[0], lists[1]);
            }
            else
            {
                int mid = lists.Length / 2;
                var leftSubList = new ArraySegment<ListNode>(lists, 0, mid).ToArray();
                var rightsubList = new ArraySegment<ListNode>(lists, mid, lists.Length - mid).ToArray();
                
                return MergeTwoLists(MergeSort3(leftSubList), MergeSort3(rightsubList));
            }
        }
        private ListNode MergeSort2(ListNode[] lists)
        {
            if (lists.Length == 2)
            {
                return MergeTwoLists(lists[0], lists[1]);
            }
            else
            {
                ListNode prevSorted=null;
                ListNode newSorted;
                int i;
                for (i = 0; i < lists.Length; i=i+2)
                {
                    if (i + 1 >= lists.Length)
                        break;
                    newSorted = MergeTwoLists(lists[i], lists[i + 1]);
                    if (prevSorted == null)
                        prevSorted = newSorted;
                     else
                     {
                        prevSorted = MergeTwoLists(prevSorted, newSorted);
                     
                     }
                }
                if(lists.Length %2 == 1)
                {
                    prevSorted = MergeTwoLists(prevSorted, lists[lists.Length - 1]);
                }
                return prevSorted;
            }
        }

        private ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
                return null;

            if (list1 == null)
                return list2;
            if(list2 == null)
                return list1;

            var list3 = new ListNode();
            var tmp1 = list1;
            var tmp2 = list2;
            if (tmp1.val < tmp2.val)
            {
                list3.val = tmp1.val;
                tmp1 = tmp1.next;
            }
            else
            {
                list3.val = tmp2.val;
                tmp2 = tmp2.next;
            }

            var tmp3 = list3;

            while (tmp1 != null && tmp2 != null)
            {
                if (tmp1.val < tmp2.val)
                {
                    tmp3.next = new ListNode(tmp1.val);
                    tmp1 = tmp1.next;
                }
                else
                {
                    tmp3.next = new ListNode(tmp2.val);
                    tmp2 = tmp2.next;
                }
                tmp3 = tmp3.next;
            }
            while (tmp1 != null)
            {
                tmp3.next = new ListNode(tmp1.val);
                tmp1 = tmp1.next;
                tmp3 = tmp3.next;
            }
            while (tmp2 != null)
            {
                tmp3.next = new ListNode(tmp2.val);
                tmp2 = tmp2.next;
                tmp3 = tmp3.next;
            }

            return list3;
        }


        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            var list = new List<Node>();
            var original = new List<Node>();

            var tmp = head;
            while(tmp != null)
            {
                list.Add(new Node(tmp.val));
                original.Add(tmp);

                tmp = tmp.next;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if(i < list.Count-1)
                    list[i].next = list[i + 1];
                
                var random = original[i].random;
                
                if(random != null)
                {
                    int index = original.IndexOf(random);
                    list[i].random = list[index];
                }
                
            }

            return list[0];
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            //MergeSort

            //Split the list
            var left = head;
            var right = getMidNode(head); //its the right end of left list
            var tmp = right.next;
            right.next = null;
            right = tmp;

            left = SortList(left);
            right = SortList(right);

            var res = MergeLists(left, right);
            return res;
            //if (head == null)
            //    return null;
            //List<ListNode> list = new List<ListNode>();
            //ListNode tmp = head;
            //while(tmp != null)
            //{
            //    list.Add(tmp);
            //    tmp = tmp.next;
            //}
            //list.Sort((x,y) => x.val.CompareTo(y.val));
            //head = list[0];
            //tmp = head;
            //for (int i = 0; i < list.Count-1; i++)
            //{
            //    list[i].next = list[i + 1];
            //}
            //list[list.Count - 1].next = null;
            //ListNode prev = null;

            //bool flag = true;
            //while (flag == true)
            //{
            //    tmp = head;
            //    flag = false;
            //    while (tmp != null)
            //    {
            //        var next = tmp.next;
            //        if (next == null)
            //            break;
            //        if (tmp.val > next.val)
            //        {
            //            flag = true;
            //            if(tmp == head)
            //            {
            //                head = next;
            //            }
            //            else
            //            {
            //                prev.next = next;
            //            }
                        
            //            tmp.next = next.next;
            //            next.next = tmp;
            //        }

            //        prev = tmp;
            //        tmp = tmp.next;
            //    }
            //}

            //return head;

        }

        private ListNode MergeLists(ListNode left, ListNode right)
        {
            if (left == null && right == null)
                return null;
            if (left == null)
                return right;
            if (right == null)
                return left;

            ListNode head = null;

            var tmp1 = left;
            var tmp2 = right;

            if (tmp1.val < tmp2.val)
            {
                head = tmp1;
                tmp1 = tmp1.next;
            }
            else
            {
                head = tmp2;
                tmp2 = tmp2.next;
            }
            var tmp3 = head;

            while(tmp1 != null && tmp2 != null)
            {
                if(tmp1.val < tmp2.val)
                {
                    tmp3.next = tmp1;
                    tmp1 = tmp1.next;
                }
                else
                {
                    tmp3.next = tmp2;
                    tmp2 = tmp2.next;
                }

                tmp3 = tmp3.next;
            }

            while(tmp1 != null)
            {
                tmp3.next = tmp1;
                tmp1 = tmp1.next;
                tmp3 = tmp3.next;
            }

            while (tmp2 != null)
            {
                tmp3.next = tmp2;
                tmp2 = tmp2.next;
                tmp3 = tmp3.next;
            }

            return head;
        }

        private ListNode getMidNode(ListNode head)
        {
            var slow = head;
            var fast = head.next;
            //this will give us mid as slow
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode tmp = headA;
            var hashA = new HashSet<ListNode>();
            while(tmp != null)
            {
                hashA.Add(tmp);
                tmp = tmp.next;
            }
            tmp = headB;
            while(tmp != null)
            {
                if (hashA.Contains(tmp))
                    return tmp;
                tmp = tmp.next;
            }
            return null;
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var tmp = head.next;
            var prev = head;
            head.next = null;
            ListNode next;
            while(tmp != null)
            {
                next = tmp.next;
                tmp.next = prev;
                prev = tmp;
                tmp = next;
            }
            return prev;
        }

        public bool IsPalindrome(ListNode head)
        { //O(1) memory
            ListNode slow = head;
            ListNode fast = head;

            //find middle (after this slow will  be at middle)
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            //reverse linked list starting at middle
            ListNode prev = null;
            while(slow != null)
            {
                var temp = slow.next;
                slow.next = prev;
                prev = slow;
                slow = temp;
            }

            //check if palindrome
            var left = head;
            var right = prev;

            while(left != null && right != null)
            {
                if (left.val != right.val)
                    return false;
                left = left.next;
                right = right.next;
            }

            return true;

            ListNode tmp = head;
            List<int> list = new List<int>();
            while(tmp != null)
            {
                list.Add(tmp.val);
                tmp = tmp.next;
            }
            int l = 0;
            int r = list.Count-1;
            while(l < r)
            {
                if (list[l] != list[r])
                    return false;
                l++;
                r--;
            }
            return true;
        }

 
        //not given the head node but the node to be deleted itself
        public void DeleteNode(ListNode node) {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next  == null)
                return head;
            var odd = head;
            var even = head.next;
            var saved = even;
            var prevOdd = head;
            while(odd != null && even != null)
            {
                odd.next = even.next;
                prevOdd = odd;
                odd = odd.next;
                if (odd != null)
                {
                    even.next = odd.next;
                    even = even.next;
                }
            }
            if (odd != null)
                odd.next = saved;
            else
                prevOdd.next = saved;
            return head;
        }
    }
}
