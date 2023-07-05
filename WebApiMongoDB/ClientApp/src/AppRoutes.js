import Home from "./components/Home";
import Edit from "./components/Edit";
import New from "./components/New";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/edit',
    element: <Edit />
  },
  {
    path: '/new',
    element: <New />
  }
];

export default AppRoutes;
