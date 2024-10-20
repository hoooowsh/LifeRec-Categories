import { useState } from 'react'
import './App.css'
import Header from './components/header/Header';

function App() {
  // const [count, setCount] = useState(0)

  return (
    <div className="App">
      <Header />
      {/* Add the rest of your page content below */}
      <main>
        <h1>Welcome to the Main Page</h1>
        {/* Other components or content */}
      </main>
    </div>
  )
}

export default App
