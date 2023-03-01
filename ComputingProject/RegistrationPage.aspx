<%@ Page Title="" Language="C#" MasterPageFile="~/Evergreen.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="ComputingProject.RegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="Images/MemberIcon.png" />
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Membership Application Form</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>If you would prefer to fill this form in by hand, you can download it here:</h6>
                                    <br />
                                    <div class="form-group">
                                        <asp:Button class="btn btn-outline-secondary" ID="MembershipFormDownloadBtn" runat="server" Text="Download Form" OnClick="MembershipFormDownloadBtn_Click" />
                                    </div>

                                </center>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Applicant's Information</h5>
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="FirstNameMembershipTxt" runat="server" placeholder="First Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="LastNameMembershipTxt" runat="server" placeholder="Last Name">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="CurrentAddressMembershipTxt" runat="server" placeholder="Current Address">
                                    </asp:TextBox>
                                </div>
                            </div>

                             <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="CityMembershipTxt" runat="server" placeholder="City">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="PassNRCMembershipTxt" runat="server" placeholder="NRC/Passport Number">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EmailMembershipTxt" runat="server" placeholder="Email Address">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <br />

                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Church Affiliation</h5>
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChurchMembershipTxt" runat="server" placeholder="Church">
                                    </asp:TextBox>
                                </div>
                            </div>

                             <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChurchLocationTxt" runat="server" placeholder="Church Location">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchEmailMembershipTxt" runat="server" placeholder="Church Email">
                                    </asp:TextBox>
                                </div>
                            </div>

                             <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchCityMembershipTxt" runat="server" placeholder="City">
                                    </asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">                                 

                                    <asp:DropDownList class="form-control" ID="ChurchPositionMembershipDrpDwn" runat="server">
                                        <asp:ListItem Text ="Position at Church" value="Position at Church"></asp:ListItem>
                                         <asp:ListItem Text ="Pastor" value="Pastor"></asp:ListItem>
                                         <asp:ListItem Text ="Elder" value="Elder"></asp:ListItem>
                                         <asp:ListItem Text ="Deacon" value="Deacon"></asp:ListItem>
                                         <asp:ListItem Text ="Ordinary Church Member" value="Ordinary Church Member"></asp:ListItem>

                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ChurchStateMembershipTxt" runat="server" placeholder="Province/State">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />


                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Introduction</h5>                           
                            </div>
                        </div>
                        <br />

                        <div class="row">

                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="LibraryIntroductionMembershipTxt" runat="server" placeholder="Who introduced you to the library?">
                                    </asp:TextBox>
                                </div>
                            </div>
                            </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Applicant's Employement Information</h5>                           
                            </div>
                        </div>
                        <br />

                        <div class="row">

                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="EmploymentMembershipTxt" runat="server" placeholder="Current Employment Status">
                                    </asp:TextBox>
                                </div>
                            </div>
                            </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Membership Privileges</h5>        
                                <br />
                                <p>If you have children you would like to have library access and privileges, provide their names:</p>
                            </div>
                        </div>
                        <br />


                        
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenMembershipTxt1" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                            

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenMembershipTxt2" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                  
                        <br />

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenMembershipTxt3" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                           

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ChildrenMembershipTxt4" runat="server" placeholder="Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        
                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h5>Recommendation</h5>
                                <br />
                    
                                <p>We require a recommendation from a Pastor, Elder, Chaplain, Parent or Headteacher.
                                    Please provide their contact information:
                                </p>
                            </div>
                        </div>


                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="RecommenderNameMembershipTxt" runat="server" placeholder="Recommender's Name">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <br />
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="RecommenderPhoneMembershipTxt" runat="server" placeholder="Recommender's Phone">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="RecommenderEmailAddressMembershipTxt" runat="server" placeholder="Recommender's Email">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                         <div class="row">
                            <div class="col">
                                <h5>Login Credentials</h5>
                                <br />                                                   
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="memberUsername" runat="server" placeholder="Username" alt="Enter Username to use for future logins.">
                                    </asp:TextBox>
                                </div>
                            </div>
                        


                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="memberPassword" runat="server" placeholder="Password" alt="Enter a new password." TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                    

                        
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">                             

                                <br />
                                <br />

                                <div class="form-check">
                                    <asp:CheckBox  ID="InformationVerificationMembershipChkBx" runat="server" Text="&nbsp  I authorize the verification of the information provided on this form as to my credit." OnCheckedChanged="InformationVerificationMembershipChkBx_CheckedChanged" /> 
                                </div>

                                <br />
                               

                            </div>
                        </div>


                        <div class="row">
                            <div class="col">                             

                                <br />
                                <br />

                                <div class="form-group d-grid gap-2">
                                    <asp:Button class="btn btn-outline-secondary btn-block" ID="MemberRegisterBtn" runat="server" Text="Submit Application" OnClick="MemberRegisterBtn_Click"   />
                                </div>

                                <br />
                               

                            </div>
                        </div>
                    </div>
                </div>

                <br />

                <a href="Home.aspx"><< Home</a>
            </div>
        </div>
    </div>

</asp:Content>
