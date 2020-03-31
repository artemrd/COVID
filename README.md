# COVID-19

Virus spread model applied to the data published by Washington State Department of Health https://www.doh.wa.gov/Emergencies/Coronavirus.

The model is the following. Assume F(t) is the total number of people with the virus at time point t, including recovered ones. If R is recovery time, then the number of contagious people is F(t) - F(t - R). If P is total population, then the number of people who can potentially get the virus is P - F(t). Hence within infinitesimal time period dt the number of new cases will be
dF(t) = C * (F(t) - F(t - R)) * (P - F(t)) * dt,
where C is some 'contagiousness factor'.
