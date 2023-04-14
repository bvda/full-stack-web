import { Link, Outlet } from 'react-router-dom';

function App() {
  return (   
    <>
      <nav>
        <ul>
          <li><Link to={`/sets`}>Sets</Link></li>
          <li><Link to={`/cards`}>Cards</Link></li>
        </ul>
      </nav>
      <Outlet />
    </>
  );
}

export default App;
