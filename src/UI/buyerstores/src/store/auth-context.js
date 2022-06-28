import React, { useState, useEffect } from "react";
import { Auth, Tokens, Me } from "ordercloud-javascript-sdk";

const AuthContext = React.createContext({
  isLoggedIn: false,
  onLogout: () => {},
  onLogin: (email, password) => {},
  authToken: "",
  loggedinUser: null,
});

export const AuthContextProvider = (props) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [authToken, setAuthToken] = useState("");
  const [me, setMe] = useState(null);

  useEffect(() => {
    const storedUserLoggedInInformation = localStorage.getItem("authtoken");

    if (storedUserLoggedInInformation) {
      setIsLoggedIn(true);
      Me.Get().then((response) => {
        setMe(response);
      });
    }
  }, []);

  const logoutHandler = () => {
    localStorage.removeItem("authtoken");
    setMe(null);
    setAuthToken("");
    setIsLoggedIn(false);
  };

  const loginHandler = (username, password) => {
    setIsLoggedIn(true);
    const clientID = "BDC1AC7F-B32E-4A8D-8171-72BFC6B85329";
    const scope = ["Shopper"];
    Auth.Login(username, password, clientID, scope)
      .then((response) => {
        const token = response.access_token;
        Tokens.SetAccessToken(token);
        setAuthToken(token);
        localStorage.setItem("authtoken", token);
        Me.Get().then((response) => {
          setMe(response);
        });
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
        loggedinUser: me,
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
