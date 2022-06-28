import React, { useContext } from "react";
import Header from "./components/Header/Header";
import Home from "./components/Home/home";
import Login from "./components/Login/Login";
import AuthContext from "./store/auth-context";
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const ctx = useContext(AuthContext);
  return (
    <React.Fragment>
      <Header></Header>
      {!ctx.isLoggedIn && <Login></Login>}
    </React.Fragment>
  );
}

export default App;
