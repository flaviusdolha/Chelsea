import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './components/home/Home';
import Dashboard from './components/dashboard/Dashboard';

function App () {
  const displayName = App.name;
  
  return (
      <Router>
          <Switch>
              <Route path="/" exact component={Home} />
              <Route path="/dashboard" exact component={Dashboard} />
          </Switch>
      </Router>
    );
}

export default App;