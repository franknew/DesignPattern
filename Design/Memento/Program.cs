using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            MementoHolder holder = new MementoHolder();
            Action act = new Action();
            act.Operate("step1");
            holder.SaveMemento(act.GetMemento());
            act.Display();
            act.Operate("step2");
            holder.SaveMemento(act.GetMemento());
            act.Display();
            act.Operate("step3");
            holder.SaveMemento(act.GetMemento());
            act.Display();
            holder.CancelAction(act);
            act.Display();
            holder.CancelAction(act);
            act.Display();
            holder.CancelAction(act);
            act.Display();

            Console.ReadLine();
        }
    }

    public class ActionMemento
    {
        public string ID { get; set; }
        public DateTime ActionTime { get; set; }
        public string Name { get; set; }
    }

    public class MementoHolder
    {
        List<ActionMemento> mementoList = new List<ActionMemento>();

        public void SaveMemento(ActionMemento memento)
        {
            mementoList.Add(memento);
        }

        public void CancelAction(Action action)
        {
            mementoList.RemoveAt(mementoList.Count - 1);
            if (mementoList.Count > 0)
            {
                action.RestoreMemento(mementoList[mementoList.Count - 1]);
            }
            else
            {
                action.ID = "";
                action.ActionTime = DateTime.MinValue;
                action.Name = "";
            }
        }
    }

    public class Action
    {
        public string ID { get; set; }
        public DateTime ActionTime { get; set; }
        public string Name { get; set; }


        public ActionMemento GetMemento()
        {
            ActionMemento memento = new ActionMemento();
            memento.ID = this.ID;
            memento.Name = this.Name;
            memento.ActionTime = this.ActionTime;
            return memento;
        }

        public void RestoreMemento(ActionMemento memento)
        {
            this.ID = memento.ID;
            this.Name = memento.Name;
            this.ActionTime = memento.ActionTime;
        }

        public void Operate(string name)
        {
            this.Name = name;
            this.ID = Guid.NewGuid().ToString();
            this.ActionTime = DateTime.Now;
        }

        public void Display()
        {
            Console.WriteLine("ID:{0}, Name:{1}, DateTime:{2}", this.ID, this.Name, this.ActionTime.ToString());
        }
    }
}
