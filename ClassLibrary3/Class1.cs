using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace ClassLibrary3
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementID> selectedIds = uidoc.Selection.GetElementIds();
            TaskDialog.Show("Revit", "So luong doi tuong duoc chon: " + selectedIds.Count.ToString());
            ICollection<ElementId> selectedWallIds = new List<ElementID>();
            for reach (ElementId id in selectedIds)
                {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }
            }
            // Set
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count) 
            {
                TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + "doi tuong Tuong da chon!");
            }
            else 
            {
                TaskDialog.Show("Revit", "Ko co doi tuong Tuong nao dc chon!");
            }
            return Result.Succeeded;
        }
    }
}
