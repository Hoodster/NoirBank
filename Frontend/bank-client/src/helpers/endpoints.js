const dbDomain = 'http://localhost:31310'
const endpoints = {
	userAPI: `${dbDomain}/api/user`,
	bankAccountAPI: `${dbDomain}/api/bankaccount`,
	cardAPI: `${dbDomain}/api/card`
}

export const { userAPI, bankAccountAPI, cardAPI } = endpoints
export default endpoints 