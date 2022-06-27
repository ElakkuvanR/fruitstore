import React, { useContext } from "react";
import Header from "./components/Header/Header";
import Home from "./components/Home/home";
import Login from "./components/Login/Login";
import AuthContext from "./store/auth-context";

function App() {
  const ctx = useContext(AuthContext);
  return (
    <React.Fragment>
      <Header></Header>
      <main>
        {!ctx.isLoggedIn && <Login></Login>}
        {ctx.isLoggedIn && <Home></Home>}
      </main>
    </React.Fragment>
  );
}

export default App;
