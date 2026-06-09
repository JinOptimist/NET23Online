import { Route, Routes, useParams } from 'react-router-dom'
import { HomePage } from './pages/home-page'
import { RelicDetailPage } from './pages/relic-detail-page'

const RelicDetailRoute = function () {
  const { id } = useParams()
  return <RelicDetailPage key={id} />
}

function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/relics/:id" element={<RelicDetailRoute />} />
    </Routes>
  )
}

export default App
