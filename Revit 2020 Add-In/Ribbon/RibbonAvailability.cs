﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TorsionTools.Ribbon
{
    //Each one of the classes below allows for different availability for ribbon buttons

    class FamilyCommandAvailability : IExternalCommandAvailability
    {
        //Checks to see if the active document is a family or project
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            //Make sure there is an active document
            if (applicationData.ActiveUIDocument == null)
                return false;
            Document _doc = applicationData.ActiveUIDocument.Document;
            if (_doc.IsFamilyDocument)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SheetCommandAvailability : IExternalCommandAvailability
    {
        //Checks to see if the active view is a sheet
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.ActiveUIDocument == null)
                return false;

            if (applicationData.ActiveUIDocument.Document.ActiveView.ViewType == ViewType.DrawingSheet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class FloorPlanCommandAvailability : IExternalCommandAvailability
    {
        //Checks to see if the active view is a floor plan
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.ActiveUIDocument == null)
                return false;

            if (applicationData.ActiveUIDocument.Document.ActiveView.ViewType == ViewType.FloorPlan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class PlanCommandAvailability : IExternalCommandAvailability
    {
        //Checks to see if the active view is a Plan View of some kind
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.ActiveUIDocument == null)
                return false;

            if (applicationData.ActiveUIDocument.Document.ActiveView.ViewType == ViewType.FloorPlan || applicationData.ActiveUIDocument.Document.ActiveView.ViewType == ViewType.CeilingPlan || applicationData.ActiveUIDocument.Document.ActiveView.ViewType == ViewType.AreaPlan || applicationData.ActiveUIDocument.Document.ActiveView.ViewType == ViewType.EngineeringPlan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class ViewLiveCommandAvailability : IExternalCommandAvailability
    {
        //Checks to see if the active view is a "live" view and not a 3D, drafting, sheet or schedule
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.ActiveUIDocument == null)
                return false;

            View view = applicationData.ActiveUIDocument.Document.ActiveView;
            if (view is View3D || view is ViewDrafting || view is ViewSheet || view is ViewSchedule)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class ViewCommandAvailability : IExternalCommandAvailability
    {
        //Checks to see if the active view is anything other than a 3D, Sheet or schedule
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.ActiveUIDocument == null)
                return false;

            View view = applicationData.ActiveUIDocument.Document.ActiveView;
            if (view is View3D || view is ViewSheet || view is ViewSchedule)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
