import React, { Component } from 'react';
import Graph from './components/Graph';
import Main from './components/Main';

class App extends Component {
  render() {
    return (
      <div className="App">

        <div className="title">
          <h1>Du har 25 000,- på konto idag</h1>
        </div>

        <div className="graph">
          <Graph />
        </div>

        <div className="info">
          <Main />
        </div>

      </div>
    );
  }
}

export default App;
