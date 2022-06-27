import React, { useState, useEffect } from "react";
import { Auth, Tokens } from "ordercloud-javascript-sdk";

const AuthContext = React.createContext({
  isLoggedIn: false,
  onLogout: () => {},
  onLogin: (email, password) => {},
  authToken: "",
});

export const AuthContextProvider = (props) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [authToken, setAuthToken] = useState("");

  useEffect(() => {
    const storedUserLoggedInInformation = localStorage.getItem("isLoggedIn");

    if (storedUserLoggedInInformation === "1") {
      setIsLoggedIn(true);
    }
  }, []);

  const logoutHandler = () => {
    localStorage.removeItem("isLoggedIn");
    setIsLoggedIn(false);
  };

  const loginHandler = (username, password) => {
    localStorage.setItem("isLoggedIn", "1");
    setIsLoggedIn(true);
    const clientID = "BDC1AC7F-B32E-4A8D-8171-72BFC6B85329";
    const scope = ["Shopper"];
    Auth.Login(username, password, clientID, scope)
      .then((response) => {
        //store token, now any subsequent calls will automatically set this token in the headers for you
        const token = response.access_token;
        Tokens.SetAccessToken(token);
        setAuthToken(token);
      })
      .catch((err) => console.log(err));
  };

  return (
    <AuthContext.Provider
      value={{
        isLoggedIn: isLoggedIn,
        onLogout: logoutHandler,
        onLogin: loginHandler,
        authToken: authToken,
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
