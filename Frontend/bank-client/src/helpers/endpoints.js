const dbDomain = 'http://localhost:31310'
const endpoints = {
	userAPI: `${dbDomain}/api/user`,
	bankAccountAPI: `${dbDomain}/api/bankaccount`,
	cardAPI: `${dbDomain}/api/card`,
	transferAPI: `${dbDomain}/api/transfer`,
	customerAPI: `${dbDomain}/api/customer`,
	adminAPI: `${dbDomain}/api/admin`
}

export const { userAPI, bankAccountAPI, cardAPI, transferAPI, customerAPI, adminAPI } = endpoints
export default endpoints 