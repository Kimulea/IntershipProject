import { Suspense } from 'react';
import { Switch } from 'react-router-dom';
import './App.css';
import AppRoutes from './components/AppRoutes';
import routes from './config/routes';
import Store from './stores/UserStore';

function App() {
  return (
    <Store>
      <Suspense fallback={""}>
        <Switch>
          {routes.map((route) => (
            <AppRoutes
              isPrivate={route.isPrivate}
              key={route.path}
              path={route.path}
              component={route.component}
            />
          ))}
        </Switch>
      </Suspense>
    </Store>
  );
}

export default App;
