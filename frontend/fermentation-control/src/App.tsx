import { Routes, Route } from 'react-router-dom'
import Layout from './components/Layout/Layout'
import DashboardPage  from './pages/Dashboard/Dashboard'
import BeersPage from './pages/Beers/Beers'
import TanksPage from './pages/Tanks/Tanks'
import FermentationParameterPage from './pages/FermentationParameter/FermentationParameter'
import FermentationRecordPage from './pages/FermentationRecord/FermentationRecord'
import BatchHistoryPage from './pages/BatchHistory/BatchHistory'


function App() {
  
  return (
    <Layout>
      <Routes>
        <Route path="/" element={<DashboardPage />} />
        <Route path="/dashboard" element={<DashboardPage />} />
        <Route path="/beers" element={<BeersPage />} />
        <Route path="/tanks" element={<TanksPage />} />
        <Route path="/parameters" element={<FermentationParameterPage />} />
        <Route path="/fermentation" element={<FermentationRecordPage />} />
        <Route path="/history" element={<BatchHistoryPage />} />
      </Routes>
    </Layout>
  )
}

export default App
