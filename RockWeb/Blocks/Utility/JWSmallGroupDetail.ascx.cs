using System;

using Rock;
using Rock.Model;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Blocks.Utility
{
    public partial class JWSmallGroupDetail : RockBlock
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                ShowGroupDetails();
            }
        }

        private void ShowGroupDetails()
        {
            int groupId = PageParameter("GroupId").AsInteger();
            var groupService = new GroupService(new Rock.Data.RockContext());
            var group = groupService.Get(groupId);

            if (group == null)
            {
                ltlName.Text = "Group not found.";
                pnlContent.Visible = false;
                return;
            }

            ltlName.Text = group.Name;
            ltlDescription.Text = group.Description;
            ltlDateCreated.Text = group.CreatedDateTime?.ToShortDateString() ?? "N/A";
            ltlDateModified.Text = group.ModifiedDateTime?.ToShortDateString() ?? "N/A";
            ltlCapacity.Text = group.GroupCapacity.HasValue ? group.GroupCapacity.Value.ToString() : "Unlimited";
        }
    }
}
