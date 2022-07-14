import React, { useContext } from "react";
import AuthContext from "../../store/auth-context";
import { Navbar, Dropdown, Avatar } from "flowbite-react";

const NavDropDown = (props) => {
  const ctx = useContext(AuthContext);

  const logoutHandler = (event) => {
    ctx.onLogout();
  };
  const loggedinUserName = ctx.loggedinUser? ctx.loggedinUser.FirstName : "";
  return (
    <Dropdown
      arrowIcon={false}
      inline={true}
      label={
        <Avatar
          alt="User settings"
          img="/user.png"
          rounded={true}
        />
      }
    >
      {ctx.isLoggedIn && (
        <React.Fragment>
          <Dropdown.Header>
            <span className="block text-sm">
              {loggedinUserName.toUpperCase()}
            </span>
          </Dropdown.Header>
          <Dropdown.Item>Dashboard</Dropdown.Item>
          <Dropdown.Item>Settings</Dropdown.Item>
          <Dropdown.Divider />
          <Dropdown.Item onClick={logoutHandler}>Sign out</Dropdown.Item>
        </React.Fragment>
      )}
    </Dropdown>
  );
};

export default NavDropDown;
