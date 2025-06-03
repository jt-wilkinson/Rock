// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using Rock;
using Rock.Model;
using Rock.Web.UI;

namespace RockWeb.Blocks.Utility
{
    public partial class JWSmallGroupList : RockBlock
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                BindGroups();
            }
        }

        private void BindGroups()
        {
            var groupService = new GroupService(new Rock.Data.RockContext());

            Guid smallGroupGuid = new Guid("50FCFB30-F51A-49DF-86F4-2B176EA1820B");
            var smallGroupType = new GroupTypeService(new Rock.Data.RockContext()).Get(smallGroupGuid);

            if (smallGroupType == null) return;

            var groups = groupService.Queryable()
                .Where(g => g.GroupTypeId == smallGroupType.Id && g.IsActive)
                .OrderBy(g => g.Name)
                .ToList();

            rptGroups.DataSource = groups;
            rptGroups.DataBind();
        }

        protected void rptGroups_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewGroup")
            {
                int groupId = e.CommandArgument.ToString().AsInteger();
                if (groupId > 0)
                {
                    Response.Redirect($"/page/841?GroupId={groupId}");
                }
            }
        }

        public string GetGroupDetailUrl(object groupIdObj)
        {
            int groupId = groupIdObj.ToString().AsInteger();
            // Partially confused on setting up pages, hardcoded the detail page ID.
            string detailPage = GetAttributeValue("DetailPage") ?? "841";
            return $"/page/{detailPage}?GroupId={groupId}";
        }

    }
}
