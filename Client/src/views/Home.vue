<template>
    <v-app>
        <v-content>
            <v-container class="fill-height" fluid>
                <v-row align="center" justify="center">
                    <v-col cols="12" sm="8" md="8">
                        <v-card class="elevation-12">
                            <v-window v-model="step">
                                <v-window-item :value="1">
                                    <v-row>
                                       <v-col cols="12" md="8">
                                          <v-card-text class="mt-12">
                                              <h1 class="text-center display-2 teal--text text-accent-3">Bine ai venit!</h1>
                                              <div class="text-center" mt-4>
                                                  <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab fa-facebook-f</v-icon>
                                                  </v-btn>
                                                  <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab fa-google-plus-g</v-icon>
                                                  </v-btn>
                                                  <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab fa-linkedin-in</v-icon>
                                                  </v-btn>
                                              </div>
                                              <h4 class="text-center mt-4">Introdu Email-ul pentru a te conecta</h4>
                                              <v-form>
                                                  <v-text-field v-model="email"
                                                  id = "email"
                                                  label="Email"
                                                  name="Email"
                                                  prepend-icon="email"
                                                  type="text"
                                                  color="teal accent-3"
                                                  />
                                                  <v-text-field v-model="password"
                                                  id="password"
                                                  label="Parola"
                                                  name="Password"
                                                  prepend-icon="lock"
                                                  type="password"
                                                  color="teal accent-3"/>

                                              </v-form>
                                              <h3 class="text-center mt-3">Ti-ai uitat parola ?</h3>
                                          </v-card-text> 
                                          <div class="text-center mt-3">
                                              <v-btn rounded color="teal accent-3" dark @click="logare" >CONECTEAZA-TE</v-btn>
                                          </div>
                                       </v-col> 
                                       <v-col cols="12" md="4" class="teal accent-3">
                                           <v-card-text class="white--text mt-12">
                                               <h1 class="text-center display-1">Salut! Esti nou?</h1>
                                               <h5 class="text-center">Introduceți datele dvs. personale și începeți călătoria cu noi</h5>
                                           </v-card-text>
                                           <div class="text-center">
                                               <v-btn rounded outlined dark @click="step++">INREGISTREAZA-TE</v-btn>
                                           </div>
                                       </v-col>
                                    </v-row>
                                </v-window-item>
                                <v-window-item :value="2">
                                    <v-row class="fill-height">
                                        <v-col cols="12" md="4" class="teal accent-3" >
                                            <v-card-text class="white--text mt-12">
                                                <h1 class="text-center display-1">Ai deja un cont?</h1>
                                                <h5 class="text-center">Va rugam sa va introduceti datele dvs. personale pentru a va conecta</h5>
                                            </v-card-text>
                                            <div class="text-center">
                                               <v-btn rounded outlined dark @click="step--">CONECTEAZA-TE</v-btn>
                                            </div>
                                        </v-col>
                                        <v-col cols="12" md="8">
                                            <v-card-text class="mt-12">
                                                <h1 class="text-center diplay-2 teal--text text--accent-3">Creaza-ti contul</h1>
                                                <div class="text-center mt-4">
                                                    <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab fa-facebook-f</v-icon>
                                                  </v-btn>
                                                  <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab fa-google-plus-g</v-icon>
                                                  </v-btn>
                                                  <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab fa-linkedin-in</v-icon>
                                                  </v-btn>
                                                </div>
                                                <h4 class="text-center mt-4">Introdu Email-ul pentru a te conecta</h4>
                                                <v-form>
                                                    <v-text-field v-model="name"
                                                        id="name"
                                                        label="Name"
                                                        name="Nume"
                                                        prepend-icon="person"
                                                        type="text"
                                                        color="teal accent-3"/>
                                                    <v-text-field v-model="email"
                                                        id="email"
                                                        label="Email"
                                                        name="Email"
                                                        prepend-icon="email"
                                                        type="text"
                                                        color="teal accent-3"/>
                                                    <v-text-field
                                                        id="password" v-model="password"
                                                        label="Parola"
                                                        name="Password"
                                                        prepend-icon="lock"
                                                        type="password"
                                                        color="teal accent-3"/>
                                                </v-form>
                                            </v-card-text>
                                            <div class="text-center mt-n5">
                                                <v-btn rounded color="teal accent-3" dark @click="inregistrare">INREGISTREAZA-TE</v-btn>
                                            </div>
                                        </v-col>
                                    </v-row>
                                </v-window-item>
                            </v-window>
                        </v-card>
                    </v-col>
                </v-row>
            </v-container>
        </v-content>
    </v-app>
</template>

<script>
import axios from 'axios';

    export default {
    name: 'Home',
    components: {
        
        
    },
    data: () => ({
            step: 1,
            email: '',
            password: '',
            name: '',
            idClient: ''
            
        }),
    props: {
        source: String
    },
    methods: {
        verificareId (id) {
            if(id == 1)
                    alert("Admin");
            if(id > 1)
            {
                    //this.$router.push('/about');
                    this.$router.push({ name: 'About', params: { idClient: id } });

            }
            if(id == '')
                    alert("Userul nu a fost gasit \nVa rugam sa reintroduceti datele corect!");
        },

        logare(){
            if (this.email == '' || this.password == '')
                alert("Va rugam sa introduceti adresa de mail corect \nVa rugam sa introduceti parola corect");
            else
            {
                if(this.email != '' && this.password != '')
                {
                    const email = this.email;
                    const password = this.password;
                    this.idClient = '';
                    axios.post("http://localhost:5000/api/login", {
                        email,password})
                    .then(res => this.verificareId(res.data));
                    this.email = '';
                    this.password = '';
                }    
                
            }
           
        },
        verifiacareIdInregistrare(clnt)
        {
            if(clnt == 0)
            {
                alert("Va rugam sa introduceti alta adresa de mail!")
            }
            else{
                
                this.email = '';
                this.name = '';
                this.password = '';
                alert("Inregistrare cu succes! \nVa rugam sa va conectati.")
                this.step --;
            }
           
        },
        inregistrare()
        {
            if (this.email == '' || this.password == '' || this.name =='')
                alert("Va rugam sa completati toate campurile");
            else
            {
                if(this.email != '' && this.password != '' && this.name != '')
                {
                    const email = this.email;
                    const password = this.password;
                    const name = this.name;
                     axios.post("http://localhost:5000/api/client", {
                        email,password,name})
                    .then(res => this.verifiacareIdInregistrare(res.data.id))
                    .catch(err=> console.log(err));
                    
                }
            }
        }

    }
    };
</script>
