using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteSchedules
{
    internal static class Utils
    {
        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel currentPanel = GetRibbonPanelByName(app, tabName, panelName);

            if (currentPanel == null)
                currentPanel = app.CreateRibbonPanel(tabName, panelName);

            return currentPanel;
        }

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }

        internal static List<ViewSchedule> GetAllSchedules(Document doc)
        {
            List<ViewSchedule> m_schedList = new List<ViewSchedule>();

            FilteredElementCollector curCollector = new FilteredElementCollector(doc);
            curCollector.OfClass(typeof(ViewSchedule));

            //loop through views and check if schedule - if so then put into schedule list
            foreach (ViewSchedule curView in curCollector)
            {
                if (curView.ViewType == ViewType.Schedule)
                {
                    m_schedList.Add((ViewSchedule)curView);
                }
            }

            return m_schedList;
        }

        internal static List<string> GetAllSSINames(Document doc)
        {
            FilteredElementCollector m_colSSI = new FilteredElementCollector(doc);
            m_colSSI.OfClass(typeof(ScheduleSheetInstance));

            List<string> m_returnList = new List<string>();
            
            foreach(ScheduleSheetInstance curInstance in m_colSSI)
            {
                string schedName = curInstance.Name as string;
                m_returnList.Add(schedName);

                return m_returnList;
            }

            return m_returnList;
        } 

        internal static List<string> GetAllScheduleNames(Document doc)
        {
            List<ViewSchedule> m_schedList = GetAllSchedules(doc);

            List<string> m_Names = new List<string>();

            foreach(ViewSchedule curSched in m_schedList)
            {
                m_Names.Add(curSched.Name);                
            }

            return m_Names;
        }

        internal static List<string> GetSchedulesNotUsed(List<string> schedNames, List<string> schedInstances)
        {
            IEnumerable <string> m_returnList;

            m_returnList = schedNames.Except(schedInstances);

            return m_returnList.ToList();
        }

        internal static List<ViewSchedule> GetSchedulesToDelete(List<string> schedNotUsed)
        {
            // how to convert list of strings back into list of view schedules
            
            throw new NotImplementedException();
        }
    }
}
