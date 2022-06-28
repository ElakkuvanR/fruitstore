import React, { useContext } from "react";
import { NavDropdown } from "react-bootstrap";
import AuthContext from "../../store/auth-context";

const NavDropDown = (props) => {
  const ctx = useContext(AuthContext);

  const logoutHandler = (event) => {
    ctx.onLogout();
  };
  const loggedinUserName = ctx.loggedinUser ? ctx.loggedinUser.FirstName : "";
  return (
    <NavDropdown
      title={`Signed in as ${loggedinUserName.toUpperCase()}`}
      id="navbarScrollingDropdown"
    >
      {ctx.isLoggedIn && (
        <React.Fragment>
          {" "}
          <NavDropdown.Item href="#action3">Your Address</NavDropdown.Item>
          <NavDropdown.Item href="#action4">Payments</NavDropdown.Item>
          <NavDropdown.Divider />
          <NavDropdown.Item onClick={logoutHandler}>Logout</NavDropdown.Item>
        </React.Fragment>
      )}
    </NavDropdown>
  );
};

export default NavDropDown;
