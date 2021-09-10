import React from "react";
import store from './redux/store/index'
import './App.css'
import { Provider } from 'react-redux'
import PlantList from './components/plantList'

function App() {
  return (
    <Provider store={store}>
      <div className="App">
        <PlantList/>
      </div>
    </Provider>
  );
}

export default App;
