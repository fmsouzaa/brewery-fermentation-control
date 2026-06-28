import Layout from './components/Layout/Layout'
//import DashboardPage  from './pages/Dashboard/Dashboard'
//import BeersPage from './pages/Beers/Beers'
//import TanksPage from './pages/Tanks/Tanks'
//import FermentationParameterPage from './pages/FermentationParameter/FermentationParameter'
//import FermentationRecordPage from './pages/FermentationRecord/FermentationRecord'
import BatchHistoryPage from './pages/BatchHistory/BatchHistory'


function App() {
  
  return (
    <Layout>
      {/* <DashboardPage  /> */}
      {/* <BeersPage />  */}
      {/* <TanksPage />  */}
      {/* < FermentationParameterPage /> */}
      {/* <FermentationRecordPage/> */}
      <BatchHistoryPage />
    </Layout>
  )
}

export default App
