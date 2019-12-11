using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace AutoCAD_Plugin
{
    public class Calque_Infos
    {
        public static Document AC_DOC = Application.DocumentManager.MdiActiveDocument;
        public static Database AC_DB = AC_DOC.Database;
        public static Editor AC_EDITEUR = AC_DOC.Editor;

        [CommandMethod("Calque_Nom")]
        public static void AddLightweightPolyline()
        {
            PromptEntityResult Promp_Result = AC_EDITEUR.GetEntity("Sélectionner l'élément");

            using (Transaction TRANSACTION = AC_DB.TransactionManager.StartTransaction())
            {
                if (Promp_Result.Status == PromptStatus.OK)
                {
                    var Var_Object = (Entity)TRANSACTION.GetObject(Promp_Result.ObjectId, OpenMode.ForRead);
                    AC_EDITEUR.WriteMessage(Var_Object.Layer);
                }
            }
        }
    }
}
