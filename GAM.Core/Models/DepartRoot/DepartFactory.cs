namespace GAM.Core.Models.DepartRoot
{
    /// <summary>
    /// 聚合根工厂类，创建此聚合内所有对象
    /// </summary>
    public class DepartFactory
    {
        public static Depart CreateInstance(string name, string manager, string remark = null)
        {
            var inf = new Depart { Name = name, Manager = manager, Remarks = remark };
            return inf;
        }
    }
}
