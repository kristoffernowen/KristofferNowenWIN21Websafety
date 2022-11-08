import './App.css';
import { Routes, Route} from "react-router-dom";
import BlogFormView from "./views/BlogFormView";
import BlogPostsView from "./views/BlogPostsView";
import Navbar from "./components/Navbar";

function App() {

  return (
    <>
        <Navbar />
        <Routes>
            <Route path="/BlogFormView" element={<BlogFormView />} />
            <Route path="/" element={<BlogPostsView />} />
        </Routes>
    </>
  );
}

export default App;
