using System;

namespace GAM.Core.Models.DepartRoot
{
    /// <summary>
    /// 聚合根工厂类，创建此聚合内所有对象
    /// </summary>
    public static class DepartFactory
    {
        public static Depart GetInstance
        {
            get { return new Depart(); }
        }

        public static Depart CreateInstance(Guid departId,string name, string manager, string remarks = null)
        {
            var inf = new Depart
            {
                Name = name,
                Manager = manager,
                Remarks = string.IsNullOrEmpty(remarks) ? "暂无" : remarks
            };
            return inf;
        }
    }
}
