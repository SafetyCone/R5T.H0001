using System;
using System.Threading.Tasks;


namespace R5T.H0001.S000
{
    class Program
    {
        public static async Task Main()
        {
            //await Scripts.Instance.Remove_ExampleProject();
            //await Scripts.Instance.Get_ExampleProject();
            //await Scripts.Instance.Remove_ExampleProject_OLD();
            await Scripts.Instance.Add_ExampleProject();
            //await Scripts.Instance.Add_ExampleProject_OLD();

            //Scripts.Instance.Deserialize_ProjectDescriptor_FromJsonString();
            //Scripts.Instance.Deserialize_Guid();
        }
    }
}
